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
        int PostMotionPicture(MotionPicture newPicture);
        //Http Put
        bool EditMotionPicture(MotionPicture editedMotionPicture);
        //Http Delete
        bool DeleteMotionPicture(int id);
    }
}
