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
        public Item(string item)
        {
            this.item = item;
            this.check = check;    
        }

        public string item { get { return item; } set { item = item; } }
        public bool check { get { return check; } set { check = check; } }
    }
}