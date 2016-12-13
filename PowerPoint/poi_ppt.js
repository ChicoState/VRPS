

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import org.apache.poi.xslf.usermodel.XMLSlideShow;
import org.apache.poi.xslf.usermodel.XSLFSlide;

    FileInputStream is = new FileInputStream("path_to.ppt");
    SlideShow ppt = new SlideShow(is);
    is.close();

    Dimension pgsize = ppt.getPageSize();

    Slide[] slide = ppt.getSlides();
    for (int i = 0; i < slide.length; i++) {

        BufferedImage img = new BufferedImage(pgsize.width, pgsize.height, 1);

        Graphics2D graphics = img.createGraphics();
        graphics.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        graphics.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
        graphics.setRenderingHint(RenderingHints.KEY_INTERPOLATION,
                RenderingHints.VALUE_INTERPOLATION_BICUBIC);
        graphics.setRenderingHint(RenderingHints.KEY_FRACTIONALMETRICS,
                RenderingHints.VALUE_FRACTIONALMETRICS_ON);

        graphics.setColor(Color.white);
        graphics.clearRect(0, 0, pgsize.width, pgsize.height);
        graphics.fill(new Rectangle2D.Float(0, 0, pgsize.width, pgsize.height));

        // render
        slide[i].draw(graphics);

        // save the output
        FileOutputStream out = new FileOutputStream("slide-" + (i + 1) + ".png");
        javax.imageio.ImageIO.write(img, "png", out);
        out.close();
    }


