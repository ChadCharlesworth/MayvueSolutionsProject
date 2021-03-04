using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotionPicturesAPI.Models;

namespace MotionPicturesAPI.DAO
{
    interface IMotionPictureDAO
    {
        //Http Get
        List<MotionPicture> GetAllMotionPictures();
        //Http Get
        MotionPicture GetMotionPictureByID(int id);
        //Http Post
        MotionPicture PostMotionPicture(MotionPicture newPicture);
        //Http Put
        int EditMotionPicture(MotionPicture editedMotionPicture);
        //Http Delete
        int DeleteMotionPicture(int id);
    }
}
