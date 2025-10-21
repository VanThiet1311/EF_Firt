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
     <FormWrapper onFinish={handleLogin} typeLayout="vertical" >
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

