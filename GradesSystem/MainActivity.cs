using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace GradesSystem
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button grades, summaries, contact;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            grades = FindViewById<Button>(Resource.Id.btn_grades);
            grades.Click += Grades_Click;

            summaries = FindViewById<Button>(Resource.Id.btn_summaries);
            summaries.Click += Summaries_Click;

            contact = FindViewById<Button>(Resource.Id.btn_contact);
            contact.Click += Contact_Click;
        }

        private void Contact_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraEmail, "TheFinalSummary@gmail.com");
            StartActivity(intent);
        }

        private void Summaries_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetAction(Intent.ActionView);
            Android.Net.Uri data = Android.Net.Uri.Parse("https://1drv.ms/u/s!Av0oAhZW6UfMiy4LPXETnAlzqoxp");
            intent.SetData(data);
            StartActivity(intent);
        }

        private void Grades_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainGradesScreen));
            StartActivity(i);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}