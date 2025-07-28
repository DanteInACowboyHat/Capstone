using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Menu;
using Capstone.Objects;

namespace Capstone.Menu
{
    /// <summary>
    /// add the menu functionality to the program inheriting from abstract console menu
    /// </summary>
    class CinemaMenu : ConsoleMenu
    {
        private Cinema _manager;

        public CinemaMenu(Objects manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// create the menu using a range of menu items inheriting from the abstract menu items class, if a shape exists then add the options for things that require a shape to output something
        /// </summary>
        public override void CreateMenu()
        {
            _menuItems.Clear();
            //_menuItems.Add(new AddCircleMenuItem(_manager));
            //_menuItems.Add(new AddSquareMenuItem(_manager));
            //_menuItems.Add(new AddRectangleMenuItem(_manager));

            //if (_manager.Shapes.Count > 0)
            //{
            //    _menuItems.Add(new GetAreaMenuItem(_manager));
            //    _menuItems.Add(new GetPerimeterMenuItem(_manager));
            //    _menuItems.Add(new GetColourAreaMenuItem(_manager));
            //    _menuItems.Add(new EditExistingShapeMenu(_manager));
            //}
            _menuItems.Add(new ExitMenuItem(this));
        }
        /// <summary>
        /// add the text for each menu item to show the user options
        /// </summary>
        /// <returns></returns>
        public override string MenuText()
        {
            return "Cinema Menu" + Environment.NewLine + _manager.ToString();
        }
    }
}
