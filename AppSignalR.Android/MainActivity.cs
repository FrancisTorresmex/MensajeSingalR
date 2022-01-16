using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AppSignalR.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText edConectarme, edMensaje, edIdDispositivo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            edConectarme = FindViewById<EditText>(Resource.Id.etConectarme);
            edMensaje = FindViewById<EditText>(Resource.Id.etMensaje);
            edIdDispositivo = FindViewById<EditText>(Resource.Id.etIdDispositivo);

            Button btnConectarme = FindViewById<Button>(Resource.Id.btnConectar);
            Button btnMensaje = FindViewById<Button>(Resource.Id.btnMensaje);
            Button btnDispositivo = FindViewById<Button>(Resource.Id.btnIdDispositivo);

        }       
    }
}