import type { ReactNode } from "react";
import { Form } from "antd";

interface FormWrapperProps<T> {
  onFinish: (values: T) => void; 
  children: ReactNode;
}

export default function FormWrapper<T>({ onFinish, children }: FormWrapperProps<T>) {
  return (
    <Form<T> name="generic_form" onFinish={onFinish} layout="vertical">
      {children}
    </Form>
  );
}
