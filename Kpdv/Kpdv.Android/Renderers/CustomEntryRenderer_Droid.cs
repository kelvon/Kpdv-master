using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Kpdv.Renderers;
using Kpdv.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer_Droid)) ]
namespace Kpdv.Droid.Renderers
{
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    class CustomEntryRenderer_Droid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
}