using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace IMS.WebApp.Components.Controls.Common
{
    public partial class AutoCompleteComponent : ComponentBase
    {
        [Parameter]
        public string Label { get; set; } = string.Empty;

        [Parameter]//Fonksiyonun parametresi string, geri dönüş biçimi ItemViewModel'dir.
        public Func<string, List<ItemViewModel>>? SearchFunction { get; set; }

        private List<ItemViewModel>? searchResults = null;

        private ItemViewModel? selectedItem = null;

        private ItemViewModel? currentItem = null;
        private int currentItemIndex = -1;

        [Parameter]
        public EventCallback<ItemViewModel> OnItemSelected { get; set; }

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

        private void HandleSelectItem(ItemViewModel? item)
        {
            ClearHighlighting();

            if (item != null)
            {
                this.selectedItem = item;
                this.userInput = item?.Name ?? string.Empty;
                this.searchResults = null;

                OnItemSelected.InvokeAsync(item);
            }

        }

        private void ClearHighlighting()
        {
            searchResults = null;
            currentItem = null;
            currentItemIndex = -1;
        }

        private void OnKeyup(KeyboardEventArgs e)
        {
            if (searchResults != null && searchResults.Count > 0 && (e.Code == "ArrowDown" || e.Code == "ArrowUp"))
            {
                if (e.Code == "ArrowDown" && currentItemIndex < searchResults.Count - 1)
                {
                    currentItem = searchResults[++currentItemIndex];
                }
                else if (e.Code == "ArrowUp")
                {
                    if (currentItemIndex > 0)
                    {
                        currentItem = currentItem = searchResults[--currentItemIndex];
                    }
                    else
                    {
                        currentItem = null;
                        currentItemIndex = -1;
                    }
                }
            }
            else if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                HandleSelectItem(currentItem);
            }
        }

    }
}
