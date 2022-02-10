using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradesSystem
{
    [Activity(Label = "BagrutGradesScreen")]
    public class BagrutGradesScreen : Activity
    {
        TextView average, units;
        Button AddBagrut, refresh;
        Android.App.Dialog DefineBagrutDialog;

        BagrutGradesListAdapter Adapter;
        ExpandableListView BagrutListView;
        List<string> Bagruts;
        Dictionary<string, List<Course>> Grades;
        int previousGroup = -1;

        double AverageWeighted = 0, unit_sum = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BagrutGradesScreen);

            // Create your application here
            average = FindViewById<TextView>(Resource.Id.tv_average);
            units = FindViewById<TextView>(Resource.Id.tv_units);
            AddBagrut = FindViewById<Button>(Resource.Id.btn_BagrutAdd);
            refresh = FindViewById<Button>(Resource.Id.btn_refresh);
            BagrutListView = FindViewById<ExpandableListView>(Resource.Id.explv_bagruts);

            Bagruts = new List<string>();
            Grades = new Dictionary<string, List<Course>>();
        }
    }
}