using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // first open a ppt or .pptx file with Application object and then choose the first slide using Slides array. 
            Application pptApplication = new Application();
            Presentation pptPresentation = pptApplication.Presentations
            .Open("test.pptx", MsoTriState.msoFalse,MsoTriState.msoFalse
            , MsoTriState.msoFalse);
            //Export function to export the slide to PNG format. 

            pptPresentation.Slides[1].Export("slide.png", "png", 320, 240);

        }
    }
}


