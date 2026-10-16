using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace bai1.Models
{
    /// <summary>
    /// Đối tượng Thiết bị điện tử hỗ trợ thông báo thay đổi qua INotifyPropertyChanged
    /// để Data Binding 2 chiều tự động cập nhật lên DataGridView và các Control.
    /// </summary>
    public class Device : INotifyPropertyChanged
    {
        private string _deviceId = string.Empty;
        private string _deviceName = string.Empty;
        private string _category = string.Empty;
        private decimal _price;
        private int _quantity;

        public string DeviceId
        {
            get => _deviceId;
            set
            {
                if (_deviceId != value)
                {
                    _deviceId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DeviceName
        {
            get => _deviceName;
            set
            {
                if (_deviceName != value)
                {
                    _deviceName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Device()
        {
        }

        public Device(string deviceId, string deviceName, string category, decimal price, int quantity)
        {
            _deviceId = deviceId;
            _deviceName = deviceName;
            _category = category;
            _price = price;
            _quantity = quantity;
        }
    }
}
