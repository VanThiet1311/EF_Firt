import axios from "axios";
interface HTTPConfig { 
endpoint:string,
id?:number,
method?:"GET" | "POST" | "PUT" | "DELETE"
}
const HTTP = ({ endpoint, id, method = "GET" }:HTTPConfig) => {
return axios.create({
  method:method,
  baseURL: `http://localhost:5102/api/${endpoint}${id ? `/${id}` : ""}`,
  headers: {
    "Content-Type": "application/json",
  },
});
}
export default HTTP
