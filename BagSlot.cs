using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgInvintory
{
    class BagSlot
    { 
        private int cXGridNumber;
        private int cYGridNumber;
        private int cXGraphicLocation;
        private int cYGraphicLocation;
        private bool cFull;
        private Item cItem;

      
        public BagSlot(int cXGridNumber, int cYGridNumber, int cXGraphicLocation, int cYGraphicLocation)
        {
            this.cXGridNumber = cXGridNumber;
            this.cYGridNumber = cYGridNumber;
            this.cXGraphicLocation = cXGraphicLocation;
            this.cYGraphicLocation = cYGraphicLocation;
            cItem = null;
            cFull = false;
        }

        public int xGridNumber
        {
            set { cXGridNumber = value; }
            get { return cXGridNumber; }
        }
        public int yGridNumber
        {
            set { yGraphicLocation = value; }
            get { return yGraphicLocation; }
        }
        public int xGraphicLocation
        {
            set { cXGraphicLocation = value; }
            get { return cXGraphicLocation; }
        }
        public int yGraphicLocation
        {
            set { cYGraphicLocation = value; }
            get { return cYGraphicLocation; }
        }
        public bool full
        {
            set { cFull = value; }
            get { return cFull; }
        }
        public Item item
        {
            set { cItem = value; }
            get { return cItem; }
        }
    }
}
