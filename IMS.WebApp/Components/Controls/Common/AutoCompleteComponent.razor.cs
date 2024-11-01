using Microsoft.AspNetCore.Components;

namespace IMS.WebApp.Components.Controls.Common
{
    public partial class AutoCompleteComponent : ComponentBase
    {
        [Parameter]
        public string Label { get; set; } = string.Empty;

        [Parameter]//Fonksiyonun parametresi string, geri dönüş biçimi ItemViewModel'dir.
        public Func<string, List<ItemViewModel>>? SearchFunction { get; set; }

        private List<ItemViewModel>? searchResults = null;

        private string _userInput = string.Empty;
        public string userInput
        {
            get => _userInput;
            set
            {
                _userInput = value;

                if (!string.IsNullOrWhiteSpace(_userInput) && SearchFunction != null)
                {
                    searchResults = SearchFunction(_userInput);
                }
            }
        }

        public class ItemViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }
}
