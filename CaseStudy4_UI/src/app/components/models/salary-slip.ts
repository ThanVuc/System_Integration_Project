export interface SalarySlip {
    employeeId: number
    slipId: number
    date: string
    basicSalary: number
    allowances: number
    deduction: number
    workDaysThisMonth: number
    netSalary: number
  }