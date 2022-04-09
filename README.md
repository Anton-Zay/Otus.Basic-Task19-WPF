## Домашнее задание
WPF, создание нативного приложения в ОС Windows

### Цель:
- Создать приложение с графическим интерфейсом в Windows
- Применить базовые элементы управления и освоить принципы компоновки элементов средствами языка разметки xaml
- Освоить паттерн MVVM
### Описание/Пошаговая инструкция выполнения домашнего задания:
Базовый проект, в котором реализованы интерфейсы ICommand и INotifyPropertyChanged приложен в материалы к занятию.
Задача: для прошлой выполненной домашнего задания (тема "Деревья и кучи") необходимо реализовать графический интерфейс ввода данных (по сотрудникам и их зарплатам), задания условия на поиск и вывода найденного сотрудника:

- ввод данных по сотруднику осуществляется в текстовые поля ввода, сохранение (переход к следующему вводу ) осуществляется нажатием на кнопку "Ввести данные по сотруднику"
- для отображения списка сотрудников используется ItemsControl с описанным ItemTemplate. Список отображается по желанию либо сразу при вводе нового сотрудника, либо по команде "Отобразить сотрудников"
- в любой момент можно добавить нового сотрудника
- Элементы ввода для поиска сотрудника по зарплате и отображение результата (так как в прошлом дз не рассматривался вариант с одинаковой зп для нескольких сотрудников, то и в рамках этого не требуется)
- сообщения о найденном сотруднике и результат "ничего не найдено" можно сделать различным графическим представлением (цвет фона, шрифта и пр.)
- функциональность, связанная с хранением дерева и поиска сотрудника размещается отдельно от классов, задействованных в отображении и управлением представления (Model и ViewModel)
