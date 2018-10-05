using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AuroraSharp;

using Windows.UI.Xaml.Controls;
using NanoleafHome.Helpers;

namespace NanoleafHome.Views
{
    public sealed partial class DevicesPage : Page, INotifyPropertyChanged
    {
        private Aurora Aurara;

        public DevicesPage()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void ButtonConnect_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var ipAddress = TextBoxIpAddress.Text;
            var authToken = TextBoxAuthKey.Text;

            if (ipAddress == string.Empty || authToken == string.Empty)
            {
                var result = await AuroraHelper.ProbeForAuroras();
                if (result != null)
                {
                    var _aurora = new Aurora(result.IPAddress, "W3xbAQykPcUPVIKJ0Iv5QNPBU3vWPEOy");
                    var _effects = await _aurora.ListEffects();
                    foreach (var effect in _effects)
                        Console.WriteLine(effect);
                    return;
                }
            }

            var newDevice = new Aurora(ipAddress, authToken);

            Aurara = newDevice;

            var auroraInfo = await newDevice.GetInfo();

            TextBoxInfoDump.Text = auroraInfo;

            var auroraDevice = await Json.ToObjectAsync<AuroraDevice>(auroraInfo);

            Console.WriteLine(auroraDevice.name);

            foreach (var effect in auroraDevice.effects.effectsList)
            {
                ListBoxEffects.Items?.Add(effect);
            }

        }

        private void ListBoxEffects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox) sender;
            Console.WriteLine(item.SelectedValue);
            Aurara.SetEffect(item.SelectedValue.ToString());

        }
    }
}
