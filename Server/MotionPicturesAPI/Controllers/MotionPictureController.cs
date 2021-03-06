using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotionPicturesAPI.DAO;
using MotionPicturesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPicturesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotionPictureController : ControllerBase
    {
        private MotionPictureSQLDAO motionPictureDAO = new MotionPictureSQLDAO();

        [HttpGet]
        public ActionResult<List<MotionPicture>> ListPictures()
        {
            List<MotionPicture> pictures = new List<MotionPicture>();

            try
            {
                pictures = motionPictureDAO.GetAllMotionPictures();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
            return Ok(pictures);
        }

        [HttpGet("{id}")]
        public ActionResult<MotionPicture> GetPictureByID(int id)
        {
            MotionPicture picture = new MotionPicture();

            try
            {
                picture = motionPictureDAO.GetMotionPictureByID(id);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

            if(picture.Name != null)
            {
                return Ok(picture);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<MotionPicture> PostPicture(MotionPicture picture)
        {
            try
            {
                motionPictureDAO.PostMotionPicture(picture);
            }
            catch (Exception e)
            {

                StatusCode(500, e.Message);
            }

            return Created($"/api/MotionPicture/{picture.ID}", picture);
        }

        [HttpPut]
        public ActionResult<MotionPicture> UpdatePicture(int id, MotionPicture updatedPicture)
        {
            if(!ModelState.IsValid || updatedPicture.ID != id)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    motionPictureDAO.EditMotionPicture(updatedPicture);
                }
                catch (Exception e)
                {

                    return StatusCode(500, e.Message);
                }

                return Ok(updatedPicture);
            }
        }

        [HttpDelete]
        public ActionResult DeletePicture(int id)
        {
            bool wasSuccessful;

            try
            {
                wasSuccessful = motionPictureDAO.DeleteMotionPicture(id);
            }
            catch (Exception)
            {

                throw;
            }

            return NoContent();
        }
}
}
