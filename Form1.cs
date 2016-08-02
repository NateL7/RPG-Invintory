using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpgInvintory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // +++++++++++++++++++ Global variables +++++++++++++++++++++++++++++++++ //
        Graphics g;
        SolidBrush black = new SolidBrush(Color.Black);
        SolidBrush gray = new SolidBrush(Color.Gray);
        Pen redPen = new Pen(Color.Red, 4);
        static int xNumberOfBagSlots = 6;
        static int yNumberOfBagSlots = 6;
        static int totalBagSlots = xNumberOfBagSlots * yNumberOfBagSlots;
        BagSlot[,] bagSlot = new BagSlot[xNumberOfBagSlots,yNumberOfBagSlots];
        BagSlot inPlayerHand = new BagSlot(-1, -1, -1, -1);
        List<Item> item = new List<Item>();
        Point mouseLocation;
        bool ItemInHand = false;

        Bitmap swordPic = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/sword.png");
        Bitmap chestPlatePic = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/chestplate.png");
        Bitmap potionPic = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/Potion.png");
        Bitmap ringPic = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/ring.png");
        Bitmap lockBoxPic = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/LockBox.png");
        Bitmap shieldPic = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/sheald.png");
        Bitmap bagClosed = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/bagClosed.png");
        Bitmap bagOpen = new Bitmap("C:/Users/Nate/Desktop/rpgInvintory/Resources/bagOpen.png");
        // +++++++++++++++++ End of Global variables ++++++++++++++++++++++++++++ //



        private void Form1_Load(object sender, EventArgs e)
        {
            g = pnlBagOne.CreateGraphics();
            createBagSlots();
            createItems();
        }
        // +++++++++++++++++++ Create Objects +++++++++++++++++++++++++++++++ //
        private void createBagSlots()
        {
            for (int x = 0; x < xNumberOfBagSlots; x++)
            {
                for (int y = 0; y < yNumberOfBagSlots; y++)
                {
                    bagSlot[x, y] = new BagSlot(x, y, x * 50, y * 50);
                }
            }
        }                // called by formLoad
        private void createItems()
        {
            item.Add(new Item(swordPic, "Sword", 1));
            item.Add(new Item(chestPlatePic, "Chest Plate", 2));
            item.Add(new Item(potionPic, "Potion", 3));
            item.Add(new Item(ringPic, "Ring", 4));
            item.Add(new Item(lockBoxPic, "Lock Box", 5));
            item.Add(new Item(shieldPic, "Shield", 6));

        }
        // ++++++++++++++++++ Drawing methods +++++++++++++++++++++++++++++++++//
        private void drawBagSpacing()
        {
            g.FillRectangle(gray, 0, 0, 300, 300);

            g.FillRectangle(black, 0, 0, 300, 5);
            g.FillRectangle(black, 0, 50, 300, 5);
            g.FillRectangle(black, 0, 100, 300, 5);
            g.FillRectangle(black, 0, 150, 300, 5);
            g.FillRectangle(black, 0, 200, 300, 5);
            g.FillRectangle(black, 0, 250, 300, 5);
            g.FillRectangle(black, 0, 300, 300, 5);

            g.FillRectangle(black, 0, 0, 5, 300);
            g.FillRectangle(black, 50, 0, 5, 300);
            g.FillRectangle(black, 100, 0, 5, 300);
            g.FillRectangle(black, 150, 0, 5, 300);
            g.FillRectangle(black, 200, 0, 5, 300);
            g.FillRectangle(black, 250, 0, 5, 300);
            g.FillRectangle(black, 300, 0, 5, 305);

        }                     // called by picOpenBagOne_Click
        private void drawItemInBag(int x, int y,Item item)
        {
            if (item != null)
            {
                g.DrawImage(item.picture, x + 5, y + 5, 45, 45);
            }          
        }
        private void drawCompleteInvintory()
        {
            drawBagSpacing();
            for (int x = 0; x < xNumberOfBagSlots; x++)
            {
                for (int y = 0; y < yNumberOfBagSlots; y++)
                {
                    drawItemInBag(bagSlot[x, y].xGraphicLocation, bagSlot[x, y].yGraphicLocation, bagSlot[x, y].item);
                }
            }
        }
        // +++++++++++++ OnClick Methods +++++++++++++++++++++++++++++++++++++ //
        private void pnlBagOne_Click(object sender, EventArgs e)
        {
            drawCompleteInvintory();
            mouseLocation = PointToClient(Cursor.Position);
            int xML = mouseLocation.X - 10;
            int yML = mouseLocation.Y - 10;
            Item tempItem = null;

            if (inPlayerHand.xGridNumber == -1 && inPlayerHand.yGridNumber == -1) // This is asking, is there something in the players hand?
            {
                for (int x = 0; x < xNumberOfBagSlots; x++)
                {
                    for (int y = 0; y < yNumberOfBagSlots; y++)
                    {
                        if (bagSlot[x, y].xGraphicLocation <= xML && xML < bagSlot[x, y].xGraphicLocation + 50 &&
                            bagSlot[x, y].yGraphicLocation <= yML && yML < bagSlot[x, y].yGraphicLocation + 50)
                        {
                            if (bagSlot[x, y].item == null) break;
                            inPlayerHand.xGridNumber = 1;               // I used the xGridNumber like a bool variable in this case to tell if something was or was not already in the players hand.
                            tempItem = inPlayerHand.item;
                            inPlayerHand.item = bagSlot[x, y].item;
                            bagSlot[x, y].item = tempItem;
                            picSelectedItem.Location = mouseLocation;
                            picSelectedItem.Image = inPlayerHand.item.picture;
                            picSelectedItem.Visible = true;
                            ItemInHand = true;
                            if (bagSlot[x, y].item == null) bagSlot[x, y].full = false;
                            else bagSlot[x, y].full = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int x = 0; x < xNumberOfBagSlots; x++)
                {
                    for (int y = 0; y < yNumberOfBagSlots; y++)
                    {
                        if (bagSlot[x, y].xGraphicLocation <= xML && xML < bagSlot[x, y].xGraphicLocation + 50 &&
                            bagSlot[x, y].yGraphicLocation <= yML && yML < bagSlot[x, y].yGraphicLocation + 50)
                        {
                            tempItem = bagSlot[x, y].item;
                            bagSlot[x, y].item = inPlayerHand.item;
                            inPlayerHand.item = tempItem;
                            if (inPlayerHand.item == null)
                            {
                                picSelectedItem.Visible = false;
                                ItemInHand = false;
                                inPlayerHand.xGridNumber = -1;
                            }
                            else
                            {
                                picSelectedItem.Image = inPlayerHand.item.picture;
                            }
                            if (bagSlot[x, y].item == null) bagSlot[x, y].full = false;
                            else bagSlot[x, y].full = true;                            
                            drawCompleteInvintory();
                        }
                    }
                }
            }                  
        }
        private void picOpenBagOne_Click(object sender, EventArgs e)
        {
            if (pnlBagOne.Visible == false)
            {
                pnlBagOne.Visible = true;
                drawCompleteInvintory();
                picOpenBagOne.BackgroundImage = bagOpen; 
            }
            else if (pnlBagOne.Visible == true)
            {
                pnlBagOne.Visible = false;
                picOpenBagOne.BackgroundImage = bagClosed;
            }
        }
        private void btnLoot_Click(object sender, EventArgs e)
        {
            drawCompleteInvintory();
            Random rand = new Random();
            Item newItem = item[rand.Next(0, item.Count())];
            bool breakOut = false;
            int bagSlotcount = 1;

            for (int x = 0; x < xNumberOfBagSlots; x++)
            {
                for (int y =0; y < yNumberOfBagSlots; y++)
                {
                    if (bagSlot[x, y].full == false)
                    {
                        bagSlot[x, y].item = newItem;
                        drawItemInBag(bagSlot[x, y].xGraphicLocation, bagSlot[x, y].yGraphicLocation, newItem);
                        bagSlot[x, y].full = true;
                        breakOut = true;
                        break;                       
                    }
                    bagSlotcount++;
                }               
                if (breakOut == true) break;
            }
            if (bagSlotcount > xNumberOfBagSlots * yNumberOfBagSlots) MessageBox.Show("Bag is Full!");
        }
        private void bagTimer_Tick(object sender, EventArgs e)
        {
            if (ItemInHand == true)
            {
                picSelectedItem.Location = PointToClient(Cursor.Position);
                picSelectedItem.Top = picSelectedItem.Top - 20;
                picSelectedItem.Left = picSelectedItem.Left - 20;               
                drawCompleteInvintory();
            }
        }
        private void picSelectedItem_Click(object sender, EventArgs e)
        {
            pnlBagOne_Click(this, e);
        }
    }
}
