using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace InfoScreen1
{
    [Activity(Label = "InfoScreen1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            JavaList<string> toDo = new JavaList<string>();
            

            Button AddItem = FindViewById<Button>(Resource.Id.additem_btn);
            ListView list = FindViewById<ListView>(Resource.Id.listView1);
            EditText input = FindViewById<EditText>(Resource.Id.editText1);


            list.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) =>
            {
                int pos = e.Position;
                toDo.RemoveAt(pos);
                list.Adapter = UpdateList(toDo);
            };


            AddItem.Click += (object sender, EventArgs e) =>
            {
                string test = input.Text.ToString();
                if (test.Equals(""))
                {
                    Toast toast = Toast.MakeText(ApplicationContext, "Invalid Input", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    toDo.Add(test);
                    list.Adapter = UpdateList(toDo);
                    input.Text = "";
                }
                
            };
        }

        private ArrayAdapter UpdateList(JavaList<string> toDo)
        {
            return new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, toDo);
        }
    }
}

