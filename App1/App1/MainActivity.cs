using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AppCenter.Start("e6414a2f-72c6-4844-8034-202f3821061b",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.Start("e6414a2f-72c6-4844-8034-202f3821061b", typeof(Analytics), typeof(Crashes));
            AppCenter.Start("e6414a2f-72c6-4844-8034-202f3821061b", typeof(Distribute));

            // Set our view from the "main" layout resource
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Main);
            var btn = FindViewById<Button>(Resource.Id.button1);
            var btn2 = FindViewById<Button>(Resource.Id.button2);
            btn.Click += Btn_Click;
            btn2.Click += Btn2_Click;
            // Create a new fragment and a transaction.
            FragmentTransaction fm = this.FragmentManager.BeginTransaction();
            FirstFragment firstFragment = new FirstFragment();

            // The fragment will have the ID of Resource.Id.fragment_container.
            fm.Add(Resource.Id.frameLayout1, firstFragment);
            fm.AddToBackStack("First");

            // Commit the transaction.
            fm.Commit();

            
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            var dialogFragment = new MyDialogFragment();
            dialogFragment.Show(transaction, "dialog_fragment");
        }

        private void Btn_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction fm = this.FragmentManager.BeginTransaction();
            SecondFragment secondFragment = new SecondFragment();

            // The fragment will have the ID of Resource.Id.fragment_container.
            fm.Add(Resource.Id.frameLayout1, secondFragment);
            fm.AddToBackStack("Second");
            // Commit the transaction.
            fm.Commit();
        }
    }
}

