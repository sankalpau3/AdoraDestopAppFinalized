using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;
using ModernUIForWPFSample.WithoutBackButton;
using ModernUIForWPFSample.WithoutBackButton.Views;
using System.Data.Entity;


namespace ModernUIForWPFSample.WithoutBackButton.DAO
{
    class fobStockInHandDAO
    {
        //image folder path
        String destinationFolder = @"C:\Users\Poorna Jayasinghe\Desktop\images1\";

        //List that hold current record image name list in the memory
        List<String> currentRecordImageNameList = new List<string>();

        //Currently showing image locaton in the list. Initially it's zero
        int currentImageNumber = 0;

        // Setting current Record ID in a public variable for reference, when adding and updating image
        String currentRecordStockID;

        // this method is use to set currentRecordStockID global variable
        public void setCurrentRecordStockID(String id)
        {
            currentRecordStockID = id;
        }

        //This section is used to populate search bar with the contents( Factory Name, Item Name and Description )
        public void populateSearchBarWithAllData(ComboBox cmbBox)
        {
            try
            {
                using (adoraDBContext a = new adoraDBContext())
                {
                    //retriving factory name, item name and description from the database and saving it in a list
                    var factoryName = (from e in a.StockInHands
                                       select new { e.FactoryName, e.ItemName, e.descript }
                   ).Distinct().ToList();

                    List<String> nList = new List<string>();

                    //pulling retrived data from the list and setting them in the combo box record
                    for (int i = 0; i < factoryName.Count; i++)
                    {
                        String n = factoryName[i].FactoryName.ToString();
                        String m = factoryName[i].ItemName.ToString();
                        String l = factoryName[i].descript.ToString();

                        String nm = n + "  ->  " + m + "  ->  " + l;
                        nList.Add(nm);
                    }

                    cmbBox.ItemsSource = nList;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

 


        // this section is used to populate all other textboxes according to the selected record in searchbar
        public void populateAllOtherTextbox(ComboBox cmbBox, TextBox factoryNameTxt, TextBox itemNameTxt, DatePicker dateX, TextBox descriptionTxt, TextBox noOfPiecesTxt, TextBox costPerPieceTxt, System.Windows.Controls.Image imgX)
        {
            if (cmbBox.SelectedItem != null)
            {

                try
                {
                    using (adoraDBContext a = new adoraDBContext())
                    {
                        //getting data from the selected record in the search bar
                        String fullString = cmbBox.SelectedValue.ToString();
                        String[] facNameAndItemNameArray = Regex.Split(fullString, "  ->  ");
                        String factoryName = facNameAndItemNameArray[0];
                        String itemName = facNameAndItemNameArray[1];

                        factoryNameTxt.Text = factoryName;
                        itemNameTxt.Text = itemName;
                       
                        // retriving descrption data from the database and populating the description text box
                        var DescriptionDetails = (from e in a.StockInHands
                                                  where (e.FactoryName == factoryName && e.ItemName == itemName)
                                                  select e.descript
                                                 ).ToList();

                        descriptionTxt.Text = DescriptionDetails.First().ToString();

                        // retriving date details from the database and populating the date field
                        var dateDetails = (from e in a.StockInHands
                                                  where (e.FactoryName == factoryName && e.ItemName == itemName)
                                                  select e.Date
                       ).ToList();

                        dateX.Text = dateDetails.First().ToString();

                        // retriving no of pieces details from the database and populating the no of pieces details text box
                        var noOfPiecesDetails = (from e in a.StockInHands
                                           where (e.FactoryName == factoryName && e.ItemName == itemName)
                                           select e.NoOfItems
                       ).ToList();

                        noOfPiecesTxt.Text = noOfPiecesDetails.First().ToString();

                        try
                        {
                            // retriving cost per piece details from the database and populating the cost per piece details text box
                            var CostPerPieceDetails = (from e in a.StockInHands
                                                       join b in a.ActualCosts on e.ACostID equals b.ACostID
                                                       where (e.FactoryName == factoryName && e.ItemName == itemName)
                                                       select b.TotalCost
                           ).ToList();

                            costPerPieceTxt.Text = CostPerPieceDetails.First().ToString();
                        }
                        catch(Exception)
                        {
                            costPerPieceTxt.Text = "<< Cost per piece for this item not available >>";
                        }

                        // retriving the image stock id from the database using factory name and item number of selected record
                        var imageStockId = (from e in a.StockInHands
                                            where (e.FactoryName == factoryName && e.ItemName == itemName)
                                            select e.StockID
                       ).ToList();

                        // setting the current record stock id public variable 
                        setCurrentRecordStockID(imageStockId.Last().ToString());

                        if (imageStockId.Any())
                        {
                            String imgStockId = imageStockId.Last().ToString();

                            //retriving the image name list from the database using the image stock id
                            var imageNameList = (from e in a.Images
                                             where (e.StockID == imgStockId)
                                             select e.Link
                                       ).ToList();

                            // Setting the imageNameList to global variable currentRecordImageList
                             currentRecordImageNameList = imageNameList;

                            // Setting the first image in the image viewer
                             if (currentRecordImageNameList.Count > 0)
                             {
                                 String firstImageName = currentRecordImageNameList.First().ToString();

                                 // calling image set function to set the corresponding image in the image viewer
                                 imageSet(firstImageName, imgX);
                             } 
                             else
                             {
                                 imgX.Source = null;
                             }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        // this section is used to delete the current image showing in the image viewer
        public void deleteCurrentImage(System.Windows.Controls.Image imgX)
        {
            //update the image name list in the memory
            updateImageNameList();

            // checks there are any images related to the current record from the image name list in memory
            if (currentRecordImageNameList.Count > 0)
            {
                String currentSelectedImageName = currentRecordImageNameList[currentImageNumber];
                String currentSelectedImageId;

                using (adoraDBContext a = new adoraDBContext())
                {
                    // retriving the current image id from the database using the current selected image name and the current selected stock ID
                    var imageIdObj = (from e in a.Images
                                      where (e.Link == currentSelectedImageName && e.StockID == currentRecordStockID)
                                      select e.ImageID).First();

                    currentSelectedImageId = imageIdObj.ToString();

                    // retriving the current image object using current selected image ID
                    var deleteImage = con.Images.First(d => d.ImageID == currentSelectedImageId);

                    // removing the current image object
                    con.Images.Remove(deleteImage);

                    // saving changes to the database
                    int x = con.SaveChanges();

                    // updating the image name list in the memory after deleting the image
                    updateImageNameList();

                    try
                    {
                        // after deleting the current image, this sets the first image in the image name list to the image viewer
                        String firstImageName = currentRecordImageNameList.First().ToString();
                        imageSet(firstImageName, imgX);
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                    {
                        MessageBox.Show(e.ToString());
                        imgX.Source = null;
                        
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException)
                    {
                        imgX.Source = null;
                    }
                    catch (System.NotSupportedException)
                    {
                        imgX.Source = null;
                    }
                    catch (System.ObjectDisposedException)
                    {
                        imgX.Source = null;
                    }
                    catch (System.InvalidOperationException)
                    {
                        imgX.Source = null;
                    }
                    catch (Exception)
                    {
                        imgX.Source = null;
                    }
                    

                    // this section check whether correctly updated the database or not about the image deletion
                    // x > 0 means correcly updated
                    if (x > 0)
                    {
                        try
                        {
                            // setting the image's access permission to normal to avoid unauthorized access exception
                            File.SetAttributes(@destinationFolder + currentSelectedImageName, FileAttributes.Normal);

                            // deleting the image file on the hard drive
                            File.Delete(@destinationFolder + currentSelectedImageName);

                            // confirmation message
                            MessageBox.Show("Image Deleted","Notification");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error occured while deleting the file from the disk","Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error Occured while deleting the file entry from the database","Error");
                    }
                }
            }
            else
            {
                // if there are no images to delete this warning appears
                MessageBox.Show("There are no images to delete","Notification");
            }
        }
        
       //This section use to update Image Name list currently in the memory
        public void updateImageNameList()
        {
            using (adoraDBContext a = new adoraDBContext())
            {
                // retriving the image name list using the current selected record's stock id and store in the list
                var imageNameList = (from e in a.Images
                                     where (e.StockID == currentRecordStockID)
                                     select e.Link
                 ).ToList();

                // updating the imageNameList to global variable currentRecordImageNameList
                currentRecordImageNameList = imageNameList;
            }
        }

        // Setting image in the Image View
           public void imageSet(String imageName, System.Windows.Controls.Image imagePick)
        {
            // if image viewer visibility is hiddent this makes it visible
            if (imagePick.Visibility == Visibility.Hidden)
            {
                imagePick.Visibility = Visibility.Visible;
            }

            // full path to the image folder
            String fullPath = "C:\\Users\\Poorna Jayasinghe\\Desktop\\images1\\" + imageName;

            try
            {
                // setting image viewer source as corresponding image's full path
                imagePick.Source = LoadImage(fullPath);
            }
             catch(IOException)
            {
                // if the corresponding image missing or corrupted this method is use to notify it to the user and delete that image's path from the database
                if (MessageBox.Show("Current Image file is missing or currupted !!! Do you want to delete database record according to that image path", "Image File Missing or Corrupted", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    // Don't do anything if the user clicked No
                }
                else
                {

                    // Delete the missing image record from the database if the user approved
                    String fileNameOfTheImage = currentRecordImageNameList[currentImageNumber];
                    String deletingImageObjectID;

                    using (adoraDBContext a = new adoraDBContext())
                    {
                        // retriving deleting image record's id from the database using the file name of the image and current selected record's stock ID
                        var deletingImageObject = (from e in a.Images
                                                   where (e.StockID == currentRecordStockID && e.Link == fileNameOfTheImage)
                                                   select e.ImageID
                                                  ).ToList();

                        deletingImageObjectID = deletingImageObject.First().ToString();

                        // retriving the delete image object from the database using the image ID
                        var deleteImageObject = con.Images.First(d => d.ImageID == deletingImageObjectID);

                        //removing the image object from the database
                        con.Images.Remove(deleteImageObject);

                        // save changes in the database
                        con.SaveChanges();
                    }
                }
            }          
        }


        // this section is used to cache the image when loading it from the disk. If we didn't use this method we can't delete images because Adore application 
        // directly using the image. so it'll give another process using the file I/O exception
           private BitmapImage LoadImage(string myImageFile)
           {
               BitmapImage myRetVal = null;
               if (myImageFile != null)
               {
                   BitmapImage image = new BitmapImage();
                   using (FileStream stream = File.OpenRead(myImageFile))
                   {
                       image.BeginInit();
                       image.CacheOption = BitmapCacheOption.OnLoad;
                       image.StreamSource = stream;
                       image.EndInit();
                   }
                   myRetVal = image;
               }
               return myRetVal;
           }

           // this section is use to delete the whole record with it's all the images
           public void deleteCurrentRecordWithItsImages()
           {
               using (adoraDBContext a = new adoraDBContext())
               {    
                   // update the image name list in the memory
                   updateImageNameList();

                   // retriving image id list from the database using the current stock id public variable
                   var imageIdList = (from e in a.Images
                                      where (e.StockID == currentRecordStockID )
                                      select e.ImageID).ToList();

                   // deleting the all the images related to the currrent record
                   for(int i=0; i<imageIdList.Count; i++)
                   {
                       String deletingImageObjectID = imageIdList[i];

                       // retriving the image object from the database using the image ID
                       var deletingImageObject = con.Images.First(d => d.ImageID == deletingImageObjectID);

                       // remove the retrived image object
                       con.Images.Remove(deletingImageObject);

                       // save the changes to the database
                       con.SaveChanges();
                   }

                   // deleting the image files on the disk related to the current record
                   for(int i=0; i<currentRecordImageNameList.Count; i++)
                   {
                       String fileName = currentRecordImageNameList[i];

                       // check whether file exist or not
                       if(File.Exists(@destinationFolder + fileName))
                       {
                           // setting the image's access permission to normal to avoid unauthorized access exception
                            File.SetAttributes(@destinationFolder + fileName, FileAttributes.Normal);

                            // deleting the image file on the hard drive
                            File.Delete(@destinationFolder + fileName);
                       }

                   }

                   // retriving the stock in hand object currently selected from the database using the currect record stock id
                   // this section use to delete the main record
                   var deletingStockInHandObject = con.StockInHands.First(k => k.StockID == currentRecordStockID);

                   // deleting the retrived record from the database
                   con.StockInHands.Remove(deletingStockInHandObject);

                   // save changes to the database
                   con.SaveChanges();
               }
           }
         



        // Real time combo box drop down data updating method
           public void updateSearchComboBox(ComboBox cmbBox)
           {
               try
               {
                   using (adoraDBContext a = new adoraDBContext())
                   {
                       String searchText = cmbBox.Text.ToString();

                       // Take all the records where Factory Name, Item name or description match with the user input (Search text)
                       var factoryName = (from e in a.StockInHands
                                          where e.FactoryName.Contains(searchText) || e.ItemName.Contains(searchText) || e.descript.Contains(searchText)
                                          select new { e.FactoryName, e.ItemName, e.descript }
                      ).Distinct().ToList();

                       List<String> nList = new List<string>();

                       // setting retrived data in the list and adding them ti the combo drop down box
                       for (int i = 0; i < factoryName.Count; i++)
                       {
                           String n = factoryName[i].FactoryName.ToString();
                           String m = factoryName[i].ItemName.ToString();
                           String l = factoryName[i].descript.ToString();

                           String nm = n + "  ->  " + m + "  ->  " + l;
                           nList.Add(nm);
                       }
                       cmbBox.ItemsSource = nList;
                       cmbBox.IsDropDownOpen = true;
                   }
               }
               catch (Exception e)
               {
                   MessageBox.Show(e.ToString());
               }
           }




        ////////////////////// Data Adding Section //////////////////////////////

            ModernUIForWPFSample.WithoutBackButton.Views.Validations validationX = new ModernUIForWPFSample.WithoutBackButton.Views.Validations();
           adoraDBContext ad = new adoraDBContext();
           adoraDBContext con = new adoraDBContext();

            
        // this section is use to add and update records
           public void addUpdateRecord(RadioButton updateRButtonX, RadioButton addRButtonX, TextBox factoryNameX, TextBox itemNameX, DatePicker datePick, TextBox descriptionX, TextBox noOfPiecesX, Label errX)
           {

                    // This section is use to update records     
                   if (updateRButtonX.IsChecked == true)
                   {
                       if (validationX.allFieldsFilled(factoryNameX, itemNameX, datePick, descriptionX, noOfPiecesX))
                       {
                           // retriving the corresponding stock object that matches current record stock ID
                           var Bns = con.StockInHands.FirstOrDefault((bns) => bns.StockID == currentRecordStockID);

                           // updating the retrived object data using the new data
                           Bns.FactoryName = factoryNameX.Text;
                           Bns.ItemName = itemNameX.Text;
                           Bns.Date = datePick.SelectedDate;
                           Bns.descript = descriptionX.Text;
                           Bns.NoOfItems = Convert.ToInt32(noOfPiecesX.Text);
                           con.StockInHands.Load();

                           // saving changes to the database
                           int done = con.SaveChanges();

                           if (done > 0)
                           {
                               MessageBox.Show("Update sucessfully!","Notification");
                               validationX.resetForm(factoryNameX, itemNameX, datePick, descriptionX, noOfPiecesX, errX);
                           }
                           else
                           {
                               MessageBox.Show("You have not modified any value!","Notification");
                           }
                       }
                       else
                       {
                           MessageBox.Show("Please Fill All Fields", "Error");
                       }
                   }
              
               // This method is used to add New record to the database
               if (addRButtonX.IsChecked == true)
               {
                   // validating whether al fields are filled correctly
                   if (validationX.allFieldsFilled(factoryNameX, itemNameX, datePick, descriptionX, noOfPiecesX))
                   {
                       adoraDBContext _context = new adoraDBContext();
                       

                    StockInHand sh = new StockInHand();

                    // getting data from the textboxes and saving them in newly created object
                    sh.FactoryName = factoryNameX.Text;
                    sh.ItemName = itemNameX.Text;
                    sh.Date = datePick.SelectedDate;
                    sh.descript = descriptionX.Text;
                    sh.NoOfItems = Convert.ToInt32((noOfPiecesX.Text));
                   
                   // sh.ACostID = id;
                    
                    // adding the object to the database
                    _context.StockInHands.Add(sh);

                    // saving the object in the database
                    _context.SaveChanges();

                    System.Windows.MessageBox.Show("Succesfully Added", "Done", MessageBoxButton.OK, MessageBoxImage.Information);

                    // this section is used to set CurrentRecordStockID global variable to newly added record's stock id
                    using (adoraDBContext b = new adoraDBContext())
                    {
                        // retriving newly added record's stock id from the database
                        var newRecordStockId = (from x in b.StockInHands
                                                where (x.FactoryName == factoryNameX.Text && x.ItemName == itemNameX.Text && x.descript == descriptionX.Text)
                                                select x.StockID).ToList();

                        // setting the CurrentRecordStockID global variable
                        setCurrentRecordStockID(newRecordStockId.First().ToString());
                    }
                   }
                   else
                   {
                       MessageBox.Show("Please Fill All Fields", "Error");
                   }
               }

               if (updateRButtonX.IsChecked == false && addRButtonX.IsChecked == false)
               {
                   MessageBox.Show("Please select Add or Update", "Error");
               }
           }




        // this section is use to Upload images to the image folder
            public void imageUpload()
           {
                // this section opens Win32 file dialog box to select images from the disk
               Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                // this filters image files (JPEGs)
               dlg.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
               Nullable<bool> result = dlg.ShowDialog();

               if (result == true)
               {
                   // retriving the selected file name
                   String filename = dlg.SafeFileName;
                   String SourceFilePath = dlg.FileName;

                   // getting current date and time to generate a unique file name
                   DateTime now = DateTime.Now;
                   String currentTimeAndDate = now.ToString().Replace("/", "").Replace(" ", "").Replace(":", "");

                   // generating a unique file name using current record stock ID + current date and time and selected file's initial name
                   String uniqueFileName = currentRecordStockID + currentTimeAndDate;

                   // setting the full destination path with generated unique file name
                   String destinationPath = @destinationFolder + uniqueFileName+ filename;

                   int error = 0;

                   try
                   {
                       // copy the file to the destination path
                       File.Copy(SourceFilePath, destinationPath, true);

                       try
                       {
                           // creating a new image object and adding it to the database with the newly copied image file's data
                           Image im = new Image();
                           im.Link = uniqueFileName + filename;
                           im.StockID = currentRecordStockID;
                           
                           // adding the image object to the database
                           con.Images.Add(im);

                           // saving the changes to the database
                           con.SaveChanges();
                       }
                       catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                       {
                           MessageBox.Show(e.ToString());
                           
                       }
                       catch (System.Data.Entity.Validation.DbEntityValidationException)
                       {
                           
                       }
                       catch (System.NotSupportedException)
                       {
                           
                       }
                       catch (System.ObjectDisposedException)
                       {
                           
                       }
                       catch (System.InvalidOperationException)
                       {
                           
                       }
                       catch(Exception e)
                       {
                           MessageBox.Show(e.ToString());
                       }
                   }
                   catch (Exception)
                   {
                       MessageBox.Show("Error Occured", "Error");
                       error++;
                   }

                   if (error == 0)
                   {
                       // update the image name list in the memory if the action is successfull
                       updateImageNameList();
                       MessageBox.Show("File Upload Complete " + filename + " !!!", "Notification");
                   }
               }
           }

        // this section is use to change the images using image changing arrow
        // this changes the image viewer to the next image
          public void changeToNextImage(System.Windows.Controls.Image imgX)
          {
              // updating the image name list in the memory
              updateImageNameList();

              // check whether current record image name list has any elements or not
              if (currentRecordImageNameList.Count == 0)
              {
                  MessageBox.Show("No images found !!! Please upload images to this record", "Notification");
              }
              else
              {
                  // if the current image number pointing to the last image of the list make it point to the first image and set it's path in image set method
                  if (currentImageNumber == currentRecordImageNameList.Count - 1)
                  {
                      currentImageNumber = 0;

                      // pointing to the first image in the current record image name list and getting that image name
                      String imageName = currentRecordImageNameList[currentImageNumber];

                      // setting the first image to show in the image viewer
                      imageSet(imageName, imgX);
                  }
                  else
                  {
                      // if the current image number < size of the current record image name list. it increment the currentImageNumber varible by 1 to point to the next image 
                      // in the currentRecordImageNameList
                      currentImageNumber++;
                      String imageName;
                      try
                      {
                          // getting the next image name from the list
                          imageName = currentRecordImageNameList[currentImageNumber];

                          // setting the next image to the image viewer
                          imageSet(imageName, imgX);
                      }
                      catch(Exception)
                      {
                          // if some error occured update the imageNameList variable in the memory, resetting the image pointer and setting the first image to the viewer
                          updateImageNameList();
                          currentImageNumber = 0;
                          imageName = currentRecordImageNameList[currentImageNumber];
                          imageSet(imageName, imgX);
                      }
                  }
              }
          }

          // this section is use to change the images using image changing arrow
          // this changes the image viewer to the previous image
          public void changeToPreviousImage(System.Windows.Controls.Image imgX)
          {
              // updating the image name list in the memory
              updateImageNameList();

              // check whether current record image name list has any elements or not
              if (currentRecordImageNameList.Count == 0)
              {
                  MessageBox.Show("No images found !!! Please upload images to this record", "Notification");
              }
              else
              {
                  // if the currentImageNumber points to the first image of the list, pointer changes to the last image of the list
                  // and set that last image to the image viewer
                  if (currentImageNumber == 0)
                  {
                      currentImageNumber = currentRecordImageNameList.Count - 1;
                      String imageName = currentRecordImageNameList[currentImageNumber];
                      imageSet(imageName, imgX);
                  }
                  else
                  {
                      // else it will decrement the pointer so that'll point to the previous image in the list 
                      // and set that image to the image viewer
                      currentImageNumber--;
                      String imageName = currentRecordImageNameList[currentImageNumber];
                      imageSet(imageName, imgX);
                  }
              }
          }



    }
}
