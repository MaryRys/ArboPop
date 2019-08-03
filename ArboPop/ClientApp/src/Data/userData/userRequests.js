import axios from 'axios';
import apiKeys from '../apiKeys';

const firebaseUrl = apiKeys.firebaseKeys.databaseURL;

const getSingleUser = uid => new Promise((resolve, reject) => {
    axios.get(`${firebaseUrl}/users.json?orderBy="uid"&equalTo="${uid}"`)
      .then((result) => {
        const userObject = result.data;
        const userArray = [];
        if (userObject != null) {
          Object.keys(userObject).forEach((userId) => {
            userObject[userId].id = userId;
            userArray.push(userObject[userId]);
          });
        }
        resolve(userArray[0]);
      })
      .catch((error) => {
        reject(error);
      });
  });

export default getSingleUser;