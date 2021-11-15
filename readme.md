Консольное CRUD-приложение, финальное задание
=============================================
Реализовать консольное CRUD-приложение под свои виды данных (3 шт, по 5-6 полей в каждом). Для каждого вида данных сделать отдельное подменю. У каждого вида данных предусмотреть поле ID (должно автоматом присваиваться приложением). Желательно реализовать отдельным проектом (т.е. делать не на базе SoftwareDb).

На выходе необходимо написать краткий, но полноценный отчёт (в Word или аналогичном виде, на выходе PDF) по проделанной работе (поставленная задача, реализованная функциональность программы, архитектура, возникшие проблемы и недочёты, описание работы программы со скриншотами + произведённые тесты, выводы). В сумме 10-15 страниц. Желательно сделать титульный лист (по правилам оформления работ в ТПТ) и содержание (+ список использованный литературы, если таковая будет).

Должны быть реализованы следующие операции:
1. Чтение данных из файлов (для CSV можно сделать 3 отдельных файла, XML/JSON можно хранить всё в одном)
2. Сохранение данных в файлы на выходе из программы (с подтверждением)
3. Добавление записи
4. Изменение записи
5. Удаление записи
6. Вывод данных в виде таблицы
---
7. Проверка всех входных данных
8. Сохранение данных в файл отдельной операцией (в соотв. подменю)
9. Повторное чтение данных из файла (в соотв. подменю) 
   [разумнее всего будет добавить вспомогательную операцию в Repository]
10. Поиск (и отображение) записи (или записей) в виде списка по ID или названию. Список вида:
   * ID: 1
   * Имя: Вася
   * Фамилия: Пупкин
   * ID: 2
   * ...
11. Удаление всех записей
12. Добавление тестовых данных
    (желательно отображать данную запись, только если программа собрана в режиме DEBUG)
    #if DEBUG
    // реализация или регистрация операции
    #endif
13. Возможность смены рабочих файлов через аргументы командной строки
    (возможная схема под CSV: либо указываются три аргумента - названия каждого из файлов, 
     либо ни одного - тогда используются стандартные пути)
14. Экспорт в один из других форматов (CSV/XML/JSON, из того что НЕ использовали для хранения)
15. Экспорт в виде HTML-таблицы

...Любые другие улучшения по желанию :)
