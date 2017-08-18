using System.ComponentModel;
using Android.Graphics;
using Meaning.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(LabelFontRenderer))]
[assembly: ExportRenderer(typeof(Button), typeof(ButtonFontRenderer))]
[assembly: ExportRenderer(typeof(Entry), typeof(EntryFontRenderer))]
[assembly: ExportRenderer(typeof(Editor), typeof(EditorFontRenderer))]
//[assembly: ExportRenderer(typeof(ToolbarItem), typeof(ToolbarFontRenderer))]

namespace Meaning.Droid
{
    public class SetFont
    {
        public static string ReturnFont()
        {
            return "JosefinSans-Italic.ttf";
        }
    }

    public class LabelFontRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, SetFont.ReturnFont());
            }
        }
    }

    public class ButtonFontRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, SetFont.ReturnFont());
            }
        }
    }

    public class EntryFontRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, SetFont.ReturnFont());
            }
        }
    }

    public class EditorFontRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, SetFont.ReturnFont());
            }
        }
    }

    //public class ToolbarFontRenderer : ToolbarRenderer // not working at all - not font, not color
    //{
    //    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
    //    {
    //        base.OnElementChanged(e);
    //        if (e.OldElement == null)
    //        {
    //            var toolbarItem = Control as Android.Widget.Toolbar;
    //            var textColor = new Android.Graphics.Color(121, 68, 223);
    //            toolbarItem?.SetTitleTextColor(textColor);
    //        }
    //    }
    //}
}