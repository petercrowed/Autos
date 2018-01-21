using System.Collections.Generic;
using System.Windows.Forms;

namespace eeProGUI
{
    public class Car
    {
        public int index { get; set; }
        public string name { get; set; }
        public bool gesperrt { get; set; }
        public ImageList il { get; set; }
        public List<System.Drawing.Image> images { get; set; } = new List<System.Drawing.Image>();
        public Dictionary<string, string> infosDE { get; set; }
        public Dictionary<string, string> infosENG { get; set; }

		#region "constructors"
		/// <summary>
		/// Default Constructor
		/// </summary>
		public Car()
        {
            this.il = new ImageList();
            this.il.ImageSize = new System.Drawing.Size(110, 70);
            this.il.TransparentColor = System.Drawing.Color.Transparent;
        }

		/// <summary>
		/// Constructor for setting Name and ImageList
		/// </summary>
		/// <param name="name">Name</param>
		/// <param name="il">ImageList</param>
		public Car(string name, ImageList il)
        {
            this.name = name;
            this.il = il;
        }

		/// <summary>
		/// Constructor for setting Name and ImageList and Images
		/// </summary>
		/// <param name="name">Name</param>
		/// <param name="il">ImageList</param>
		/// <param name="images">Images</param>
		public Car(string name, ImageList il, List<System.Drawing.Image> images)
        {
            this.name = name;
            this.il = il;
            this.images = images;
        }

		/// <summary>
		/// Constructor for setting Name and ImageList and 4 pictures
		/// </summary>
		/// <param name="name">Name</param>
		/// <param name="il">ImageList</param>
		/// <param name="image1">picture 1</param>
		/// <param name="image2">picture 2</param>
		/// <param name="image3">picture 3</param>
		/// <param name="image4">picture 4</param>
		public Car(string name, ImageList il, System.Drawing.Image image1, System.Drawing.Image image2,
            System.Drawing.Image image3, System.Drawing.Image image4)
        {
            this.name = name;
            this.il = il;
            this.images.Add(image1);
            this.images.Add(image2);
            this.images.Add(image3);
            this.images.Add(image4);
        }
		#endregion

		/// <summary>
		/// addImage adds a Image to the image list of the car. There cannot be
		/// added more then 4 Images
		/// </summary>
		/// <param name="image">Image</param>
		/// <returns>true when the Image was added succesfully</returns>
		public bool addImage(System.Drawing.Image image)
        {
            if (images.Count < 4)
            {
                this.il.Images.Add(image);
                images.Add(image);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}