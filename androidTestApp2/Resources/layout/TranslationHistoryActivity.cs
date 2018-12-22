namespace androidTestApp2.Resources.layout
{
    using System.Collections.Generic;

    using Android;
    using Android.App;
    using Android.OS;
    using Android.Widget;

    [Activity(Label = "@string/translationHistory")]
    public class TranslationHistoryActivity : ListActivity
    {
        #region Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            IList<string> phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.SimpleListItem1, phoneNumbers);
        }

        #endregion
    }
}
