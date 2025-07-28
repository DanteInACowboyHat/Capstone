using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Menu
{
    /// <summary>
    /// abstract class inheriting menu item to specify for the larger menus like editing shape
    /// </summary>
    internal abstract class ConsoleMenu : MenuItem
    {
        protected List<MenuItem> _menuItems = new List<MenuItem>();

        public bool IsActive { get; set; }

        public abstract void CreateMenu();
        /// <summary>
        /// using console helpers to get the menu items whilst is active is true/creating the menus
        /// </summary>
        public override void Select()
        {
            IsActive = true;
            do
            {
                CreateMenu();
                string output = $"{MenuText()}{Environment.NewLine}";
                int selection = ConsoleHelpers.GetIntegerInRange(1, _menuItems.Count, this.ToString()) - 1;
                _menuItems[selection].Select();
            } while (IsActive);
        }
        /// <summary>
        /// outputing the menu items
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MenuText());
            for (int i = 0; i < _menuItems.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {_menuItems[i].MenuText()}");
            }
            return sb.ToString();
        }
    }
    /// <summary>
    /// class to end menu creation
    /// </summary>
    class ExitMenuItem : MenuItem
    {
        private ConsoleMenu _menu;

        public ExitMenuItem(ConsoleMenu parentItem)
        {
            _menu = parentItem;
        }
        /// <summary>
        /// overwrite to show option to end menu
        /// </summary>
        /// <returns></returns>
        public override string MenuText()
        {
            return "Exit";
        }
        /// <summary>
        /// overwrite to stop menu creation
        /// </summary>
        public override void Select()
        {
            _menu.IsActive = false;
        }
    }
}