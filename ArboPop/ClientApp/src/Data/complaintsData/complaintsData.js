import axios from 'axios';
import apiKeys from '../apiKeys';

const baseUrl = apiKeys.baseUrl;

const getAllComplaints = () => new Promise((Resolve, Reject) => {
  axios.get(`${baseUrl}/Complaints/all`)
    .then((res) => Resolve(res))
    .catch((err) => Reject(err));
});

// const deletePaymentType = paymentId => axios.delete(`${baseUrl}/payment/${paymentId}`)

// const addPayment = (paymentInfo) => new Promise((Resolve, Reject) => {
//   axios.post(`${baseUrl}/payment`, paymentInfo)
//     .then((res) => Resolve(res))
//     .catch((err) => Reject(err));
// });

export default { 
  getAllComplaints
}