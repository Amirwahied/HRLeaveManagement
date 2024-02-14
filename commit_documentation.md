# Commit Documentation

This file serves as a detailed documentation for commits made in the project, providing comprehensive information about each commit for reference purposes.

**Usage**:

This documentation can be used as a reference to track and understand the changes made in the project over time. It provides a detailed overview of each commit, allowing team members to review and analyze the project history effectively.

------

## Day (1)

### Date: 11/2/2024 (Mon Feb 12 04:33:51 2024 +0200)

### Commit Details

| Property    | Details                                                      |
| ----------- | ------------------------------------------------------------ |
| Full ID     | 21cbb9aa8f87651651e8b53c2805878a2d301b98                     |
| Short ID    | 21cbb9a                                                      |
| Message     | Initial Commit                                               |
| Description | - Add 2 projects in core layer which are Domain Project, Application Project.<br>- Add empty README file.<br>- Add .gitignore template of .NET.<br>- Create commit_documentation file.<br>- Add reference in Application project on Domain project to access Domain Entities.<br>- Create IGenericRepository interface and specific repository interface for each entity. |

### Files Added

#### In Core Layer

It contains domain entities in Domain layer and application interfaces in Application layer.

##### Core/Domain Project

It contains domain entities.

| File              | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| Common/BaseEntity | Includes common fields among entities. It contains fields:<br>- **int id:** unique identifier for each entity<br>- **DateTime CreationDate:** for Auditing to know the creation date and time<br>- **DateTime ModificationDate:** for Auditing to know the modification date and time |
| LeaveType         | Includes leave types like "Annual Leave" and "Sick Leave". It contains fields:<br>- **string Name:** leave type name and it is required field<br>- **int DefaultDays:** the default number of days for this type of leave |
| LeaveRequest      | Includes employee request for leave. It contains fields:<br>- **DateTime StartDate:** the start date of the requested leave<br>- **DateTime EndDate:** the end date of the requested leave<br>- **LeaveType LeaveType:** the type of leave that employee requested<br>- **int LeaveTypeId:** the id of leave requested<br>- **DateTime DateRequested:** the date in which employee request this leave<br>- **string? RequestComments:** if employee have any comment with request<br>- **bool? Approved:** is request approved or not<br>- **bool Cancelled:** is request is cancelled by employee or not<br>- **string RequestingEmployeeId:** the employee id that request this leave |
| LeaveAllocation   | Includes the allocation of leaves for employees in each period like 2024 or 2025. It contains fields:<br>- **LeaveType LeaveType:** the type of leave<br>- **int LeaveTypeId:** id of leave type<br>- **int NumberOfDays:** the number of days for this type of leave<br>- **int Period:** the period that the leave allocated to |

##### Core/Application Project

- It contains contracts.

- Add new Folder named Persistence (Core/Application/Persistence): it refers to the data access layer and it will contain interfaces of repositories without implementation.

| File                       | Description                                                  |
| -------------------------- | ------------------------------------------------------------ |
| IGenericRepository         | Contains methods that all database tables will use like CRUD operations.<br>- **Task<List<T>> GetAsync():** for retrieving all items, it represents R in CRUD<br>- **Task<T> GetByIdAsync(int id):** for retrieving item with id, it represents R in CRUD<br>- **Task<T> CreateAsync(T entity):** for creating new item, it represents C in CRUD<br>- **Task<T> UpdateAsync(T entity):** for updating new item, it represents U in CRUD<br>- **Task<T> DeleteAsync(T entity):** for deleting item, it represents D in CRUD |
| ILeaveTypeRepository       | Specific repository for LeaveType entity for more specific methods. It will inherit from IGenericRepository. |
| ILeaveRequestRepository    | Specific repository for LeaveRequest entity for more specific methods. It will inherit from IGenericRepository. |
| ILeaveAllocationRepository | Specific repository for LeaveAllocation entity for more specific methods. It will inherit from IGenericRepository. |

------

