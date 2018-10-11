using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Kpdv.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Kontacto")]
[assembly: ExportEffect(typeof(IOSReturnKeyEffects), "ReturnKeyEffects")]
namespace Kpdv.iOS.Effects 
{
    public class IOSReturnKeyEffects : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (Kpdv.Effects.ReturnKeyEffects)Element.Effects.FirstOrDefault(e => e is Kpdv.Effects.ReturnKeyEffects);
                if (effect == null)
                {
                    if (effect.ReturnText == "Done")
                        (Control as UITextField).ReturnKeyType = UIReturnKeyType.Done;
                    if (effect.ReturnText == "Next")
                        (Control as UITextField).ReturnKeyType = UIReturnKeyType.Next;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override void OnDetached()
        {
           
        }
    }
}