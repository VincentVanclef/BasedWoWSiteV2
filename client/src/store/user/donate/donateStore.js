import Vue from "vue";
import axios from "axios";
import store from "../../index";

const API_URL = process.env.API.DONATE;

export default {
  namespaced: true,
  // ----------------------------------------------------------------------------------
  state: {},
  // ----------------------------------------------------------------------------------
  getters: {},
  // ----------------------------------------------------------------------------------
  mutations: {},
  // ----------------------------------------------------------------------------------
  actions: {
    Donate: async (context, amount) => {
      try {
        const response = await axios.post(`${API_URL}/donate`, {
          amount: amount
        });
        window.open(response.data, "_self");
        return Promise.resolve();
      } catch (error) {
        return Promise.reject(error);
      }
    },
    CompletePayment: async (context, payload) => {
      const { userId, accountId, payerId, paymentId, token } = payload;
      try {
        const response = await axios.post(`${API_URL}/ExecutePayment`, {
          userId,
          accountId,
          payerId,
          paymentId,
          token
        });
        return Promise.resolve(response.data);
      } catch (error) {
        return Promise.reject(error);
      }
    }
  }
};
