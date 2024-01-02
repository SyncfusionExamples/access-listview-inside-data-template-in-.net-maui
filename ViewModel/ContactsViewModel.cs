using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewMaui
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<Contacts> Items { get; set; }

        #endregion

        #region Fields

        Random random = new Random(123456789);

        #endregion

        #region Constructor

        public ContactsViewModel()
        {
            Items = new ObservableCollection<Contacts>();
            var imageNames = new[] { "image_a.png", "image_b.png", "image_c.png", "image_d.png", "image_e.png" };

            for (int i = 0; i < CustomerNames.Count(); i++)
            {
                var contact = new Contacts(CustomerNames[i], random.Next(720, 799).ToString() + " - " + random.Next(3010, 3999).ToString());
                int randomImageIndex = random.Next(imageNames.Length);
                contact.ContactImage = imageNames[randomImageIndex];
                Items.Add(contact);
            }
        }

        #endregion

        #region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
        };

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
