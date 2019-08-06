
import apiKeys from '../apiKeys';
import axios from 'axios';

const baseUrl = apiKeys.baseUrl;

const getAllSamples = () => new Promise((Resolve, Reject) => {
  axios.get(`${baseUrl}/Samples/all`)
    .then((res) => Resolve(res))
    .catch((err) => Reject(err));
});

const addSample = (newSample) => new Promise((Resolve, Reject) => {
  axios.post(`${baseUrl}/Samples`, newSample)
    .then((res) => Resolve(res))
    .catch((err) => Reject(err));
});


export default {
    getAllSamples,
    addSample
}