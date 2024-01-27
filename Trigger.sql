CREATE OR REPLACE FUNCTION prevent_duplicate_trip()
RETURNS TRIGGER AS $$
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Trip
        WHERE busID = NEW.busID
          AND tDate = NEW.tDate
    ) THEN
        RAISE EXCEPTION 'Aynı gün içerisinde başka sefer ekleyemezsiniz.';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER check_duplicate_trip
BEFORE INSERT ON Trip
FOR EACH ROW
EXECUTE FUNCTION prevent_duplicate_trip();

--****************************************************************************************************************************

CREATE OR REPLACE FUNCTION check_license_date()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.driverLicenseDate <= current_date THEN
        RAISE EXCEPTION 'Geçerli bir sürücü belgesi tarihi seçilmelidir.';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trigger_check_license_date
BEFORE INSERT OR UPDATE ON Drivers
FOR EACH ROW
EXECUTE FUNCTION check_license_date();



--****************************************************************************************************************************

CREATE OR REPLACE FUNCTION drivers_control()
RETURNS TRIGGER AS $$
BEGIN
    IF (SELECT COUNT(*) FROM Drivers WHERE tripID = NEW.tripID) > 1 THEN
        RAISE EXCEPTION '1 den fazla şoför sefere eklenemez';
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER drivers_control_tetikleyici
AFTER INSERT ON Drivers
FOR EACH ROW
EXECUTE FUNCTION drivers_control();

--****************************************************************************************************************************

CREATE OR REPLACE FUNCTION asistan_control()
RETURNS TRIGGER AS $$
BEGIN
    IF (SELECT COUNT(*) FROM Assistants WHERE tripID = NEW.tripID) > 2 THEN
        RAISE EXCEPTION '2 den fazla muavin sefere eklenemez';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER asistan_control_tetikleyici
AFTER INSERT ON Assistants
FOR EACH ROW
EXECUTE FUNCTION asistan_control();

--****************************************************************************************************************************

CREATE OR REPLACE FUNCTION check_card_expiry()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.cardDate > CURRENT_DATE THEN
        RETURN NEW;
    ELSE
        RAISE EXCEPTION 'Kredi kartınızın süresi dolmuştur!';
    END IF;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER check_card_expiry_trigger
AFTER INSERT OR UPDATE ON Passenger
FOR EACH ROW
EXECUTE FUNCTION check_card_expiry();

--****************************************************************************************************************************

CREATE OR REPLACE FUNCTION total_cost_kontrol()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.totalCost > 500 THEN
        RAISE EXCEPTION 'Toplam maliyet 500 den büyük olamaz';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trigger_total_cost_kontrol
BEFORE INSERT OR UPDATE ON Costs
FOR EACH ROW
EXECUTE FUNCTION total_cost_kontrol();

--****************************************************************************************************************************

CREATE OR REPLACE FUNCTION check_driver_age()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.driverDate <= current_date - interval '60 years' THEN
        RAISE EXCEPTION 'Sürücü 60 yaşından büyük olduğu için sefere çıkamaz!';
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER check_driver_age_trigger
BEFORE INSERT OR UPDATE ON Drivers
FOR EACH ROW
EXECUTE FUNCTION check_driver_age();