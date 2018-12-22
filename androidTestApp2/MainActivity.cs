namespace androidTestApp2
{
    using System.Collections.Generic;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Widget;

    using Core;

    using Resources.layout;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        #region Fields

        private static readonly List<string> _phoneNumbers = new List<string>();

        #endregion

        #region Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            var translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            var translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            var translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);

            translateButton.Click += (sender, e) =>
            {
                string translatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);

                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = string.Empty;
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                    _phoneNumbers.Add(translatedNumber);
                    translationHistoryButton.Enabled = true;
                }
            };

            translationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", _phoneNumbers);
                StartActivity(intent);
            };
        }

        #endregion
    }
}
