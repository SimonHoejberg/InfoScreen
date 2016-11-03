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
            JavaList<Item> toDo = new JavaList<Item>();
            
            
            Button AddItem = FindViewById<Button>(Resource.Id.additem_btn);
            ListView list = FindViewById<ListView>(Resource.Id.listView1);
            EditText input = FindViewById<EditText>(Resource.Id.editText1);

            list.ChoiceMode = ChoiceMode.Multiple;

            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, toDo);
            list.Adapter = adapter;

            list.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) =>
            {
                int pos = e.Position;
                toDo.RemoveAt(pos);
                adapter.NotifyDataSetChanged();
            };

            list.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                bool ticked = !toDo[e.Position].Check;
                list.SetItemChecked(e.Position, ticked);
                toDo[e.Position].Check = ticked;
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
                    toDo.Add(new Item(test, false));
                    adapter.NotifyDataSetChanged();
                    //adapter.Add(toDo);
                    input.Text = "";
                }
            };
        }
    }
}

