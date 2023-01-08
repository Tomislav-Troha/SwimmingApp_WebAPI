CREATE OR REPLACE FUNCTION Training_Select(_id int)
RETURNS TABLE (id int, code varchar, trainingtype varchar)
AS
$$
	SELECT id, code, trainingtype
	FROM   "Training"
	WHERE (id = _id OR _id IS NULL );
$$
lANGUAGE SQL;