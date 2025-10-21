import { Table } from "antd";
import type { TableProps } from "antd";
import type { ReactNode } from "react";

interface TableWrapperProps<T> extends TableProps<T> {
  dataSource: T[];
  columns: TableProps<T>["columns"];
  loading?: boolean;
  children?: ReactNode;
}

export default function TableData<T extends { id: React.Key }>({
  dataSource,
  columns,
  loading,
  ...rest
}: TableWrapperProps<T>) {
  return (
    <Table<T>
        dataSource={dataSource}
        columns={columns}
        loading={loading}
        rowKey="id"
        pagination={{
        pageSize: 10,
        showSizeChanger: true,
        pageSizeOptions: ["5", "10", "20", "50"],
        showQuickJumper: false,
      }}
      {...rest}
    />
  );
}
