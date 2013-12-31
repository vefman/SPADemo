using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

using HomeSecurity.Data.Entity;
using HomeSecurity.Data.Repository;

using HomeSecurity.Domain.Data.Model;
using HomeSecurity.Domain.Data.ViewData;

namespace HomeSecurity.Domain.Helper.Home
{
    public struct MediaRequest
    {
        public int? PictureSkip { get; set; }
        public int? PictureCount { get; set; }
        public int? VideoSkip { get; set; }
        public int? VideoCount { get; set; }
    }

    public class HomeHelper : BaseMediaHelper
    {
        public HomeHelper(HomeSecurityEntities dataContext)
            :base(dataContext)
        {

        }

        #region Get Methods

        public IEnumerable<PictureViewData> GetPictures(int? skip, int? count)
        {
            List<PictureViewData> result = new List<PictureViewData>();

            PictureRepository pictureRep = this.RepositoryFactory.CreateRepository<PictureRepository>();

            var pictures = pictureRep.GetPictures();

            pictures = pictures.OrderBy(p => p.MediaDate).Skip(skip ?? 0);

            if (count.HasValue && count > 0)
            {
                pictures = pictures.Take(count.Value);
            }

            var pictureList = pictures.ToList();

            foreach (Medium picture in pictureList)
            {
                PictureViewData viewData = new PictureViewData(picture, this.PictureDropFolder);
                result.Add(viewData);
            }

            return result;
        }

        public IEnumerable<VideoViewData> GetVideos(int? skip, int? count)
        {
            List<VideoViewData> result = new List<VideoViewData>();

            VideoRepository videoRep = this.RepositoryFactory.CreateRepository<VideoRepository>();

            var videos = videoRep.GetVideos();
            
            videos = videos.OrderBy(p => p.MediaDate).Skip(skip ?? 0);

            if (count.HasValue && count > 0)
            {
                videos = videos.Take(count.Value);
            }                   

            var videoList = videos.ToList();

            foreach (Medium video in videoList)
            {
                VideoViewData viewData = new VideoViewData(video, this.VideoDropFolder);
                result.Add(viewData);
            }

            return result;
        }

        #endregion

        #region Add Methods

        public PictureViewData AddPicture(string location, string description)
        {
            PictureViewData result = null;

            Medium picture = new Medium()
            {
                MediaID = Guid.NewGuid(),
                MediaDate = DateTime.Now,
                MediaName = location,
                MediaDescription = description,
                MediaType = "P"
            };

            PictureRepository picRep = this.RepositoryFactory.CreateRepository<PictureRepository>();

            picRep.AddPicture(picture);
            picRep.SaveChanges();

            result = new PictureViewData(picture, this.PictureDropFolder);

            return result;
        }

        public VideoViewData AddVideo(string location, string description, string poster, string posterDescription)
        {
            VideoViewData result = null;

            Medium video = new Medium()
            {
                MediaID = Guid.NewGuid(),
                MediaDate = DateTime.Now,
                MediaName = location,
                MediaDescription = description,
                MediaType = "V"
            };

            if(string.IsNullOrEmpty(poster))
            {
                PictureViewData pictureView = AddPicture(poster, posterDescription);
                video.Media1.Add(pictureView.MediaData);
            }

            VideoRepository videoRep = this.RepositoryFactory.CreateRepository<VideoRepository>();

            videoRep.AddVideo(video);
            videoRep.SaveChanges();

            result = new VideoViewData(video, this.VideoDropFolder);

            return result;
        }

        #endregion

        #region Delete Methods

        public void DeleteMedia(Guid id)
        {
            MediaRepository mediaRep = this.RepositoryFactory.CreateRepository<MediaRepository>();

            Medium media = mediaRep.GetMedia(id);

            mediaRep.DeleteMedia(media);
            mediaRep.SaveChanges();
        }        

        #endregion

        #region Edit Methods

        public void EditMedia(Guid id, string description)
        {
            MediaRepository mediaRep = this.RepositoryFactory.CreateRepository<MediaRepository>();

            Medium media = mediaRep.GetMedia(id);

            media.MediaDescription = description;

            mediaRep.SaveChanges();
        }

        #endregion
    }
}
