import { FormWrapper } from "../components/form";
import { Input, Button, Checkbox, Form } from "antd";
import { LockOutlined, UserOutlined } from "@ant-design/icons";

interface LoginData {
  email: string;
  password: string;
}

const Login = () => {
  const handleLogin = (values: LoginData) => {
    console.log("Login data:", values);
  };
  return (
    <>
      <FormWrapper<LoginData> onFinish={handleLogin}>
        <Form.Item
          label="Email"
          name="email"
          rules={[
            { required: true, message: "Vui lòng nhập email!" },
            { type: "email", message: "Email không hợp lệ!" },
          ]}
        >
          <Input prefix={<UserOutlined />} placeholder="Email" />
        </Form.Item>

        <Form.Item
          label="Mật khẩu"
          name="password"
          rules={[{ required: true, message: "Vui lòng nhập mật khẩu!" }]}
        >
          <Input.Password prefix={<LockOutlined />} placeholder="Mật khẩu" />
        </Form.Item>

        <Form.Item name="remember" valuePropName="checked">
          <Checkbox>Ghi nhớ đăng nhập</Checkbox>
        </Form.Item>

        <Form.Item>
          <Button type="primary" htmlType="submit" className="w-full">
            Đăng nhập
          </Button>
        </Form.Item>
      </FormWrapper>
    </>
  );
};

export default Login;

// import { Button, Form, Input, Modal, Popconfirm, Table } from "antd";
// import { useEffect, useState } from "react";
// import './index.css'
// interface CustomerChannelModel {
//   id: number;
//   name: string;
//   email: string;
// }
// const App = () => {
//   const [data, setData] = useState<CustomerChannelModel[]>([]);
//   const [loading, setLoading] = useState<boolean>(false);
//   const  [isModalOpen, setIsModalOpen] = useState(false);
//     const [form] = Form.useForm();
//    async function fetchData() {
//       setLoading(true);
//       const response = await fetch("http://localhost:5102/api/customers");
//       const jsonData = await response.json();
//       console.log(jsonData);
//       setData(jsonData);
//       setLoading(false);
//     }
//   useEffect(() => {
//     fetchData();  
//   }, []);
//   const handleEdit = (record: CustomerChannelModel)=>{
//     console.log(record);
    
//   }
//   const handleDelete = async (id: number) => {
//        console.log(id);
//         await fetch(`http://localhost:5102/api/customers/${id}`,{
//          method: "DELETE",
//          });
//         setData(data.filter(item => item.id !== id));
         
//   };
//    const handleOk = () => {
//     form.validateFields().then((values) => {
//       console.log("Updated values:", values);
//       // TODO: Gọi API hoặc cập nhật state
//       setIsModalOpen(false);
//     });
//   };

//   const handleCancel = () => {
//     setIsModalOpen(false);
//   };
//   const columns = [
//     {
//       title: "ID",
//       dataIndex: "id",
//       key: "id",
//     },
//     {
//       title: "NAME",
//       dataIndex: "name",
//       key: "name",
//     },
//     {
//       title: "EMAIL",
//       dataIndex: "email",
//       key: "email",
//     },
//     {
//       title: "Action",
//       key: "action",
//       render: (_: any, record: CustomerChannelModel) => (
//         <div style={{ display: "flex", gap: 8 }}>
//           <Button type="primary" onClick={() => handleEdit(record)}>
//             Sửa
//           </Button>
//           <Popconfirm
//             title="Bạn có chắc muốn xóa?"
//             onConfirm={() => handleDelete(record.id)}
//             okText="Yes"
//             cancelText="No"
//           >
//             <Button type="default" danger>
//               Xóa
//             </Button>
//           </Popconfirm>   
//         </div>
//       ),
//     },
//   ];
//   return (
//     <div >
//       <Table
//         dataSource={data}
//         loading={loading}
//         rowKey="id"
//         columns={columns}
//         pagination={{
//         pageSize: 10,      
//         showSizeChanger: true, 
//         pageSizeOptions: ['5', '10', '20', '50'], 
//        showQuickJumper: false, 
//   }}
//       />
//        <Modal
//         title="Chỉnh sửa thông tin"
//         open={isModalOpen}
//         onOk={handleOk}
//         onCancel={handleCancel}
//       >
//         <Form form={form} layout="vertical">
//           <Form.Item name="name" label="Name" rules={[{ required: true }]}>
//             <Input />
//           </Form.Item>
//           <Form.Item name="age" label="Age" rules={[{ required: true }]}>
//             <Input type="number" />
//           </Form.Item>
//         </Form>
//       </Modal>
//     </div>
//   );
// };

// export default App;

