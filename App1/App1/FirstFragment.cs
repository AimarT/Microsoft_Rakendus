using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class FirstFragment : Fragment, Android.App.DatePickerDialog.IOnDateSetListener
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment            
            var view = inflater.Inflate(Resource.Layout.FirstFragment, container, false);
            view.FindViewById<Button>(Resource.Id.dateButton).Click += (sender, args) =>
            {
                var dialog = new DatePickerDialogFragment(Activity, DateTime.Now, this);
                dialog.Show(FragmentManager, null);
            };
            return view;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            var date = new DateTime(year, monthOfYear +1, dayOfMonth);
            View.FindViewById<TextView>(Resource.Id.dateTextView).Text = "Sa valisid: " + date.ToString("yyyy-MMM-dd");
        }
    }
}