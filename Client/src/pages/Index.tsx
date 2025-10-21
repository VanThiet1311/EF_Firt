import { Button, Form, Input, Modal, Popconfirm, Table } from "antd";
import { useEffect, useState } from "react";
import CustomerService from "../services/CustomerService";
import './index.css'
interface CustomerChannelModel {
  id: number;
  name: string;
  email: string;
}
const Index = () => {
  const [data, setData] = useState<CustomerChannelModel[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const  [isModalOpen, setIsModalOpen] = useState(false);
    const [form] = Form.useForm();
    const getAllCustomerData = async () => { 
       const data =  await CustomerService.handleGetAllCustomers()
       setData(data);
    }
  useEffect(() => {
    getAllCustomerData();  
  }, []);

 
   const handleOk = () => {
    form.validateFields().then((values) => {
      console.log("Updated values:", values);
      // TODO: Gọi API hoặc cập nhật state
      setIsModalOpen(false);
    });
  };

  const handleCancel = () => {
    setIsModalOpen(false);
  };
  const columns = [
    {
      title: "ID",
      dataIndex: "id",
      key: "id",
    },
    {
      title: "NAME",
      dataIndex: "name",
      key: "name",
    },
    {
      title: "EMAIL",
      dataIndex: "email",
      key: "email",
    },
    {
      title: "Action",
      key: "action",
      render: (_: any, record: CustomerChannelModel) => (
        <div style={{ display: "flex", gap: 8 }}>
          <Button type="primary" onClick={() => handleEdit(record)}>
            Sửa
          </Button>
          <Popconfirm
            title="Bạn có chắc muốn xóa?"
            onConfirm={() => handleDelete(record.id)}
            okText="Yes"
            cancelText="No"
          >
            <Button type="default" danger>
              Xóa
            </Button>
          </Popconfirm>   
        </div>
      ),
    },
  ];
  return (
    <div >
      <Table
        dataSource={data}
        loading={loading}
        rowKey="id"
        columns={columns}
        pagination={{
        pageSize: 10,      
        showSizeChanger: true, 
        pageSizeOptions: ['5', '10', '20', '50'], 
       showQuickJumper: false, 
  }}
      />
       <Modal
        title="Chỉnh sửa thông tin"
        open={isModalOpen}
        onOk={handleOk}
        onCancel={handleCancel}
      >
        <Form form={form} layout="vertical">
          <Form.Item name="name" label="Name" rules={[{ required: true }]}>
            <Input />
          </Form.Item>
          <Form.Item name="age" label="Age" rules={[{ required: true }]}>
            <Input type="number" />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default Index;

