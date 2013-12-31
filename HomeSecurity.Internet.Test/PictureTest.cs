using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HomeSecurity.Internet.Controllers;
using HomeSecurity.Domain.Data.ViewData;

namespace HomeSecurity.Internet.Test
{
    [TestClass]
    public class PictureTest
    {
        [TestMethod]
        public void PictureController_Get_Test()
        {
            PictureController pictureController = new PictureController();

            IEnumerable<PictureViewData> target =  pictureController.Get(0, 0);

            Assert.IsNotNull(target);
        }
    }
}
