import HTTP from "../configs/http";

interface TypeCustomer { 
    id: number;
}
const CustomerService = {
  handleGetAllCustomers: async ():Promise<TypeCustomer[]> => {
    return await HTTP({ endpoint: "customers" });
  },
  handleGetDetailCustomers: async () => {
    return await HTTP({ endpoint: "customers" });
  },
};
export default CustomerService;
