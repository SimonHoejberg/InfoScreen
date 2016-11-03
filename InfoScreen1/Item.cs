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

namespace InfoScreen1
{
    class Item
    { 
        public string Items { get; set; }
        public bool Check { get; set; }

        public Item(string items, bool check)
        {
            Items = items;
            Check = check;    
        }

        public override string ToString()
        {
            return Items;
        }
    }
}