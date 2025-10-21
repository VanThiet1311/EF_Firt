import type { ReactNode } from "react";
import { Form } from "antd";

interface FormWrapperProps<T> {
  onFinish: (values: T) => void; 
  children: ReactNode;
  typeLayout: 'horizontal' | 'vertical' | 'inline';
}

export default function FormWrapper<T>({ onFinish, children , typeLayout }: FormWrapperProps<T>) {
  return (
    <Form<T> name="generic_form" onFinish={onFinish} layout={typeLayout}>
      {children}
    </Form>
  );
}
