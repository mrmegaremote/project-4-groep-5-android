using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using BarChart;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button crabButton = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate { button.Text = string.Format("{0} Hitlers in a pond!", count++); };
            button.LongClick += delegate { button.Text = string.Format($"{count++} is love, {count++} is life"); DrawGraph(); };
        }

        private void DrawGraph()
        {
            var data = new[] { 1, 6, 7, 5, 1, 3, 3, 7 };
            var chart = new BarChartView(this)
            {
                ItemsSource = System.Array.ConvertAll(data, v => new BarModel { Value = v })
            };

            chart.SetX(200);
            chart.SetY(500);
            AddContentView(chart, new ViewGroup.LayoutParams(1000, 600));
        }
    }
}