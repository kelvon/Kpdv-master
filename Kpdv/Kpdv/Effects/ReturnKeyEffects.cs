using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Kpdv.Effects
{
    public class ReturnKeyEffects : RoutingEffect
    {
        public string ReturnText { get; set; }
        /// <summary>
        /// Effect para passar de um campo pra outro na edição dos campos
        /// </summary>
        public ReturnKeyEffects() : base("Kontacto.ReturnKeyEffects")
        {

        }
    }
}

// Referencia =>  xmlns:MyEffects="clr-namespace:Kpdv.Effects"

// MUDA O BOTÃO DO TECLADO PARA NEXT
//  <Entry.Effects>
//     <MyEffects:ReturnKeyEffects ReturnText = "Next" />
//  </Entry.Effects >

// MUDA O BOTÃO DO TECLADO PARA Done
//  <Entry.Effects>
//     <MyEffects:ReturnKeyEffects ReturnText = "Done" />
//  </Entry.Effects >