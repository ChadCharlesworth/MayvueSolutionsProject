import axios from 'axios';
axios.defaults.baseURL = "https://localhost:44341/"
export default {
    listPictures() {
        return axios.get('api/motionpicture');
    },
    getPictureByID(id) {
        return axios.get(`api/motionpicture/${id}`);
    },
    addMotionPicture(motionPicture) {
        return axios.post('api/motionpicture', motionPicture);
    },
    updateMotionPicture(id, motionPicture) {
        return axios.put(`api/motionpicture/${id}`, motionPicture)
    },
    deleteMotionPicture(id) {
        return axios.delete(`api/motionpicture/${id}`);
    }
}