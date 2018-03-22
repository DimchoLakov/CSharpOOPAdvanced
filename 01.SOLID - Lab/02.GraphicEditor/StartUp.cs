using System;

namespace P02.Graphic_Editor
{
    public class StsartUp
    {
        public static void Main()
        {
            var graphicEditor = new GraphicEditor();
            graphicEditor.DrawShape(new Circle());
            graphicEditor.DrawShape(new Rectangle());
            graphicEditor.DrawShape(new Square());
        }
    }
}
