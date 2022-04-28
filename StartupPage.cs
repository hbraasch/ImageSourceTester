using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSourceTester
{
    internal class StartupPage: ContentPage
    {
        public StartupPage()
        {
            var image1 = new Image
            {
                Aspect = Aspect.AspectFill,
            };
            var fullFilename = ZippedFiles.GetFullFilename("austonomus_australis_head.jpg");
            if (File.Exists(fullFilename))
            { 
                image1.Source = ImageSource.FromFile(fullFilename);
            }

            var image2 = new Image
            {
                Aspect = Aspect.AspectFill,
            };
            image2.Source = "dory_stenotis_facial.jpg";

            Content = image1;

            ToolbarItems.Add(new ToolbarItem("Image1", "", () => { Content = image1; }, ToolbarItemOrder.Primary));
            ToolbarItems.Add(new ToolbarItem("Image2", "", () => { Content = image2; }, ToolbarItemOrder.Primary));
        }
    }
}
