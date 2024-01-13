-- Making this lookup list not editable by the user will prevent it from appearing in the
-- list of views menu.
UPDATE LookupLists SET EditableByUser = 0 WHERE ListID = 7;