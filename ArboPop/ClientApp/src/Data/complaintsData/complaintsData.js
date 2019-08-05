import axios from 'axios';
import apiKeys from '../apiKeys';

const baseUrl = apiKeys.baseUrl;

const getAllComplaints = () => new Promise((Resolve, Reject) => {
  axios.get(`${baseUrl}/Complaints/all`)
    .then((res) => Resolve(res))
    .catch((err) => Reject(err));
});

const addComplaint = (complaintInfo) => new Promise((Resolve, Reject) => {
  axios.post(`${baseUrl}/Complaints`, complaintInfo)
    .then((res) => Resolve(res))
    .catch((err) => Reject(err));
});

export default { 
  getAllComplaints,
  addComplaint
}